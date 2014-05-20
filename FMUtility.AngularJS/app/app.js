'use strict';

angular.module('app', [
        'ngRoute',
        'app.filters',
        'app.controllers',
        'app.directives',
        'app.services'
    ]).
    config(["$routeProvider", function ($routeProvider) {
        $routeProvider.when("/players", { templateUrl: "app/partials/players.html", controller: "PlayersController" });
        $routeProvider.when("/clubs", { templateUrl: "app/partials/clubs.html", controller: "ClubController" });
        $routeProvider.otherwise({ redirectTo: "/" });
    }]);