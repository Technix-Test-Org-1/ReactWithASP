import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import App from './App';
import registerServiceWorker from './registerServiceWorker';
//import { PublicClientApplication } from '@azure/msal-browser';
//import { MsalProvider } from '@azure/msal-react';


const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const rootElement = document.getElementById('root');

ReactDOM.render(
  <BrowserRouter basename={baseUrl}>
    <App />
  </BrowserRouter>,
  rootElement);

registerServiceWorker();

//const msalConfig = {
//    auth: {
//        clientId: 'd18c29a4-3489-4780-a30c-e400c0c02f74',
//        authority: 'https://login.microsoftonline.com/088e9b00-ffd0-458e-bfa1-acf4c596d3cb',
//        redirectUri: 'https://localhost:44383/',
//    },
//    cache: {
//        cacheLocation: 'localStorage',
//        storeAuthStateInCookie: true,
//    },
//};

//const pca = new PublicClientApplication(msalConfig);

//ReactDOM.render(
//    <MsalProvider instance={pca}>
//        <App />
//    </MsalProvider>,
//    document.getElementById('root')
//);
