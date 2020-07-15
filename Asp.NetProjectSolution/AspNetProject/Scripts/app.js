'use strict'

//Declare app level module which depends on filters, and services
angular.module('smApp', ['ngRoute', 'smApp.controllers', 'smApp.AppServices', 'ngExDialog', function () {
}])
//Configure the routes
.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
    .when('/main', {
        templateUrl: '/Pages/sampleMain.html',
        controller: 'sampleController'
    })
    .when('/second', {
        templateUrl: '/Pages/sampleSecond.html',
        controller: 'sampleController2'
    })
    ;
    $routeProvider.otherwise({ redirectTo: '/main' });
}])
//Dialog default settings.
.config(['exDialogProvider', function (exDialogProvider) {
    exDialogProvider.setDefaults({        
        template: 'ngExDialog/commonDialog.html', //from cache
        //template: 'ngExDialog/commonDialog_0.html', //from file
        width: '330px',
        //Below items are set within the provider. Any value set here will overwrite that in the provider.
        //closeByXButton: true,
        //closeByClickOutside: true,
        //closeByEscKey: true,
        //appendToElement: '',
        //beforeCloseCallback: '',
        //grayBackground: true,
        //cacheTemplate: true,
        //draggable: true,
        //animation: true,
        //messageTitle: 'Information',
        //messageIcon: 'info',
        //messageCloseButtonLabel: 'OK',
        //confirmTitle: 'Confirmation',
        //confirmIcon: 'question',
        //confirmActionButtonLabel: 'Yes',
        //confirmCloseButtonLabel: 'No'
    });
}])
;

