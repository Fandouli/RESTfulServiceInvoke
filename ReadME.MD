# Project Title

RESTfulServiceInvoke

## Getting Started

Cross platform Xamarin and windows plugin to invoke RESTful web service from PCL, shared project or even from specific platform project


### Installing

from the Package Manager Console type Install-Package AFA.RESTful.Service.Invoke

## How to use

Depend to your needed method (used in the web service implementation) POST or GET

For POST methode do like that :
ResultDataType result= await RESTfulServiceInvoke.Invoke<ResultDataType>(WebServiceUri,Metode.POST,ParamHeader);

ResultDataType : the data type to return
WebServiceUri : the web service uri 
ParamHeader : the header params to use in your web service implementation for filtering data

Exemple:
User user=new User{Email="UsenName@email.com"};
Uri webServiceUri = new Uri("http://yourServerUri/api/findUser");
User result= await RESTfulServiceInvoke.Invoke<User>(webServiceUri,Metode.POST,user);
if(result != null)
{
	//data returned correctly
}
else
{
	//There is aan error
}


------------------------------------------------------

For GET methode do like that :
ResultDataType result= await RESTfulServiceInvoke.Invoke<ResultDataType>(WebServiceUri,Metode.GET);

ResultDataType : the data type to return
WebServiceUri : the web service uri 

Exemple:
Uri webServiceUri = new Uri("http://yourServerUri/api/findUserByEmail/UsenName@email.com");
User result= await RESTfulServiceInvoke.Invoke<User>(webServiceUri,Metode.GET);
if(result != null)
{
	//data returned correctly
}
else
{
	//There is aan error
}




## Contributing

thank you for submitting pull requests to us.


## Authors

* **Abdessamii FANDOULI** 