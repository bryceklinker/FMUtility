'use strict';

var app = angular.module('app', [
    'ngRoute',
    'ngLocale',
    'ui.bootstrap',
    'app.controllers',
    'app.services'
])
.config(['$routeProvider', function($routeProvider){
        $routeProvider.when('/players', {
                templateUrl: 'partials/players.html',
                controller: 'playerCtrl'
            });

        $routeProvider.when('/clubs', {
            templateUrl: 'partials/clubs.html',
            controller: 'clubCtrl'
        });

        $routeProvider.when('/home', {
            templateUrl: 'partials/home.html',
            controller: 'homeCtrl'
        });

        $routeProvider.otherwise({redirectTo: '/home' });
    }]);