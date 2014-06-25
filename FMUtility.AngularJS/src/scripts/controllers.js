'use strict';

angular.module('app.controllers', ['app.services'])
    .controller('playerCtrl', ['$scope', 'Player', function($scope, Player){
        $scope.title = 'Players';
        $scope.search = function(){
            Player.search($scope);
        }
    }])
    .controller('clubCtrl', ['$scope', function($scope){
        $scope.title = 'Clubs';
    }])
    .controller('homeCtrl', ['$scope', function($scope){
        $scope.title = 'FM Utility';
    }]);