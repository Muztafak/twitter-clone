import React, { Component, Fragment } from "react";
import {Route, Routes} from "react-router";
import { Login } from "./Login";
import { Logout } from "./Logout";
import { LoginActions, LogoutActions } from "./ApiAuthorizationConstants";
import { CompleteRegistration } from "./CompleteRegistration";
import AuthorizeRoute from "./AuthorizeRoute";

export default class ApiAuthorizationRoutes extends Component {
	render() {
		return (
			<Fragment>
				<Routes>
					<Route path={LoginActions.Login} element={<Login action={LoginActions.Login}></Login>} />
					<Route path={LoginActions.LoginFailed} element={<Login action={LoginActions.LoginFailed}></Login>} />
					<Route path={LoginActions.LoginCallback} element={<Login action={LoginActions.LoginCallback}></Login>} />
					<Route path={LoginActions.Profile} element={<Login action={LoginActions.Profile}></Login>} />
					<Route path={LoginActions.Register} element={<Login action={LoginActions.Register}></Login>} />
					<Route path={LogoutActions.Logout} element={<Logout action={LogoutActions.Logout}></Logout>} />
					<Route
						path={LogoutActions.LogoutCallback}
						element={<Logout action={LogoutActions.LoggedOut}></Logout>}
					/>
					<Route path={LogoutActions.LoggedOut} element={<Logout action={name}></Logout>} />
					{<Route path="complete-registration" element={<AuthorizeRoute><CompleteRegistration/></AuthorizeRoute>} />}
				</Routes>
				
			</Fragment>
		);
	}
}