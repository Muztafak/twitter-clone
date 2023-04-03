import React from "react";
import { IPostDto } from "../core/WebApiClient";
import Post from "./Post";
import FollowerActivity from "./FollowerActivity";
import PostButtonRow from "./PostButtonRow";
import Card from "../shared/Card";
import { useNavigate } from "react-router-dom";

const PostCard: React.FC<IPostDto> = (props) => {
	const navigate = useNavigate();

	return (
		<Card onClick={() => navigate(`/status/${props.id}`)} className="p-3">
			<FollowerActivity {...props} />
			<Post post={props}>
				<PostButtonRow post={props} />
			</Post>
		</Card>
	);
};

export default PostCard;
