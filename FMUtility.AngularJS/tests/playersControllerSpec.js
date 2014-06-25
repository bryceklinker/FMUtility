'use strict';

describe('Players Controller', function() {
    var $scope;
    var player;
    var controller;
    var players;
    beforeEach(module('app.services', function($provide){
        player = jasmine.createSpyObj('Player', ["search"]);
        players = [
            {
                'Id': 123,
                'FirstName': 'bob',
                'LastName': 'john'
            }
        ];
        player.search.andCallFake(function(){
           return players;
        });
        $provide.value('Player', player);
    }));
    beforeEach(module('app.controllers'));
    beforeEach(inject(function($controller, $rootScope, Player){
        $scope = $rootScope.$new();
        player = Player;

        controller = $controller('playerCtrl', {
            $scope: $scope,
            Player: player
        });
    }));

    it('should set title', function(){
        expect($scope.title).toBe('Players');
    });

    it('should set search', function(){
        expect($scope.search).toBeDefined();
    });

    it('search should search player', function(){
        $scope.search();
        expect(player.search).toHaveBeenCalledWith($scope);
    });
});