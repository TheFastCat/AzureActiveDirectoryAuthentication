  ///////////////////////////////////////////////
 //// OVERVIEW               version 0.0.03 ////
///////////////////////////////////////////////

	This solution is useful for learning how Azure Active Directory interacts with an application in order to provide authentication and authorization
	using Active Directory Authentication Library (ADAL). Information on ADAL can be found here: http://goo.gl/EzRE6d.


	The arguments are specific to our Azure Active Directory SalesApplication tenant and are associated with application entries we've added within it.
	Ask Reid for associated credentials to login when prompted during execution of the Client application.

	Other implementors can modify arguments of Client.csproj to point to their own deployment of an Azure Active Directory tenant as described in the 
	tutorial, above.

  ///////////////////////////////
 //// NativeClient & WebAPI ////
///////////////////////////////

	These projects are coded implementation of the following tutorial: 

		http://goo.gl/ZFZX95

	and represent the use case of a native client application (READ:Windows desktop application) being authenticated via Azure Active Directory

  ///////////////////
 //// WebClient ////
///////////////////

	WebClient.csproj relates to this tutorial: http://goo.gl/OAo6XS

	and represent the use case of a client web application being authenticated via Azure Active Directory