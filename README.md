I am working on this as time permits!

# OAuth Authorization Server #
**OAuth Authorization Server - .NET Core and IdentityServer4**

**Isue access tokens for APIs for various types of clients.**


	1. Server to server             
	2. Web applications 
	3. SPAs 
	4. Native/mobile apps	

	Discovery endpoint
	http://host:port/.well-known/openid-configuration
 

**SSL / Cert Issues**

IIS Express Development cert has to be imported into the dev machine's Trusted Root Certificate Store
in order to run this over TLS.
