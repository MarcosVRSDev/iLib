/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

export const environment = {
  production: false,
  api_url: 'https://localhost:44312/api',
  firebase : {
    apiKey: "AIzaSyCKPMb9d4NEwtpb22XUCMXpN3_DN-FVGuc",
    authDomain: "laender-47951.firebaseapp.com",
    databaseURL: "https://laender-47951.firebaseio.com",
    projectId: "laender-47951",
    storageBucket: "laender-47951.appspot.com",
    messagingSenderId: "652991560597",
    appId: "1:652991560597:web:baec8c92543c3323b6949c"
  }
};
