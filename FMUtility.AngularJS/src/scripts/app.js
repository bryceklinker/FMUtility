'use strict';

angular.module('app', [
    'ngRoute',
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
        })

        $routeProvider.when('/', {
            templateUrl: 'partials/home.html',
            controller: 'homeCtrl'
        });

        $routeProvider.otherwise('/')
    }]);