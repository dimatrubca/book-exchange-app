const oidcConfiguration = {
  client_id: "client",
  redirect_uri: "http://localhost:3000/authentication/callback",
  response_type: "token id_token",
  scope: "openid profile api1",
  post_logout_redirect_uri: "http://localhost:3000/",
  authority: "http://localhost:5050",
  silent_redirect_uri: "http://localhost:3000/authentication/silent_callback",
  automaticSilentRenew: true,
  filterProtocolClaims: true,
  loadUserInfo: true,
  monitorSession: true,
};

export { oidcConfiguration };
