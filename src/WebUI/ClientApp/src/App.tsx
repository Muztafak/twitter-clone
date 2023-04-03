import React, { useEffect, useState } from "react";
import { Route, Routes } from "react-router";
import { useLocation } from "react-router-dom"
import ApiAuthorizationRoutes from "./auth/ApiAuthorizationRoutes";
import { ApplicationPaths } from "./auth/ApiAuthorizationConstants";
import Layout from "./layout/Layout";
import Feed from "./feed/Feed";
import { Provider, useDispatch } from "react-redux";
import store from "./core/Store";
import "./styles.css";
import UserProfile from "./user/UserProfile";
import authService from "./auth/AuthorizeService";
import { FollowsClient, NotificationsClient } from "./core/WebApiClient";
import { setFollows } from "./core/actions/FollowsActions";
import AuthorizeRoute from "./auth/AuthorizeRoute";
import PostAnswers from "./feed/PostAnswers";
import { addNotification, addNotifications } from "./core/actions/NotificationsActions";
import Notifications from "./notifcations/Notifications";
import { HubConnection, HubConnectionBuilder } from "@microsoft/signalr";
import Conversations from "./conversations/Conversations";

const ApplicationRoutes: React.FC = () => {
	const dispatch = useDispatch();
	const [hubConnection, setHubConnection] = useState<HubConnection>(undefined);

	const onLoggedIn = async (id: number) => {
		const follows = await new FollowsClient().getUserFollows(id);
		dispatch(setFollows(follows));

		const notifications = await new NotificationsClient().get();
		dispatch(addNotifications(notifications));

		const connection = new HubConnectionBuilder()
			.withAutomaticReconnect()
			.withUrl("/hubs/notifications", { accessTokenFactory: () => authService.getAccessToken() })
			.build();
		await connection.start();
		connection.on("Notification", (notif) => dispatch(addNotification(notif)));
	};

	const onLoggedOut = async () => {
		dispatch(setFollows(undefined));
		if (!!hubConnection) {
			await hubConnection.stop();
			setHubConnection(undefined);
		}
	};

	const onAuthStateChanged = async () => {
		const domainUser = await authService.getDomainUser();
		if (!!domainUser) {
			await onLoggedIn(domainUser.id);
		} else {
			await onLoggedOut();
		}
	};

	useEffect(() => {
		onAuthStateChanged();
		const subscription = authService.subscribe(() => onAuthStateChanged());
		return () => {
			authService.unsubscribe(subscription);
		};
	}, []);

	const location = useLocation();
	
	return (
		<Layout showSidebar={!location.pathname.startsWith("/messages")}>
			<Routes>
				<Route path="/" element={<Feed/>} />
				<Route path="/status/:id" element={<PostAnswers/>} />
				<Route path="/messages" element={<Conversations/>} />
				<Route path="/notifications" element={<Notifications/>} />
				<Route path="/:username" element={<UserProfile/>} />
			</Routes>
		</Layout>
	);
};

export const App: React.FC = () => {
	return (
		<Provider store={store}>
			<Routes>
				{/*<Route path="/authentication/login" element={<>rtsrhyertye5</>} />*/}
				<Route path={`${ApplicationPaths.ApiAuthorizationPrefix}/*`} element={<ApiAuthorizationRoutes/>} />
				<Route path="*" element={<AuthorizeRoute><ApplicationRoutes/></AuthorizeRoute>} />
			</Routes>
		</Provider>
	);
};
