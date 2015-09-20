var AwesomeAngularMVCApp = angular.module('AwesomeAngularMVCApp', ['ui.router', 'ui.bootstrap']);

AwesomeAngularMVCApp.controller('LandingPageController', LandingPageController);
AwesomeAngularMVCApp.controller('LoginController', LoginController);
AwesomeAngularMVCApp.controller('RegisterController', RegisterController);

AwesomeAngularMVCApp.factory('AuthHttpResponseInterceptor', AuthHttpResponseInterceptor);
AwesomeAngularMVCApp.factory('LoginFactory', LoginFactory);
AwesomeAngularMVCApp.factory('RegistrationFactory', RegistrationFactory);

var configFunction = function ($stateProvider, $httpProvider, $locationProvider) {

    $locationProvider.hashPrefix('!').html5Mode({
        enabled: true,
        requireBase: false
    });

    $stateProvider
        .state('Root', {
            url: '/',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/one'
                }
                //, "nestedView@stateOne": {
                //    templateUrl: '/routesDemo/four'
                //}
            }
        })
        .state('stateOne', {
            url: '/stateOne',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/one'
                }
                //, "nestedView@stateOne": {
                //    templateUrl: '/routesDemo/four'
                //}
            }
        })
        .state('stateTwo', {
            url: '/stateTwo',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/two'
                }
                //, "containerTwo": {
                //    templateUrl: '/routesDemo/three'
                //}
            }
        })
        .state('stateThree', {
            url: '/stateThree',
            views: {
                "containerOne": {
                    templateUrl: '/routesDemo/three'
                }
            }
        })
        .state('loginRegister', {
            url: '/loginRegister?returnUrl',
            views: {
                "containerOne": {
                    templateUrl: '/Account/Login',
                    controller: LoginController
                },
                "containerTwo": {
                    templateUrl: '/Account/Register',
                    controller: RegisterController
                }
            }
        });

    $httpProvider.interceptors.push('AuthHttpResponseInterceptor');
}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider'];

AwesomeAngularMVCApp.config(configFunction);
