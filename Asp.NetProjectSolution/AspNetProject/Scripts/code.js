'use strict'

//Declare app level module which depends on filters, and services
angular.module('smApp', ['smApp.controllers', 'smApp.AppServices', 'ngExDialog', function () {
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


$rootScope.$on('$locationChangeSuccess', function () {
    $rootScope.actualLocation = $location.path();
});

$rootScope.$watch(function () { return $location.path() }, function (newLocation, oldLocation) {
    if ($rootScope.actualLocation === newLocation) {
        alert('Why did you use history back?');
    }
});
