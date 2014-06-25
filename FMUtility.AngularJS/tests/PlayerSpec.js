'use strict';

describe('Player', function(){
    var httpBackend;
    var player;
    var $scope;

    beforeEach(module('app.services'));
    beforeEach(inject(function($rootScope, $httpBackend, _Player_){
        $httpBackend
            .whenGET('http://localhost:9000/player/search?name=name&current=100&potential=200')
            .respond([
                {
                    'Id': 1,
                    'FirstName': 'Billy',
                    'LastName': 'Bob'
                }
            ]);

        $scope = $rootScope.$new();
        httpBackend = $httpBackend;
        player = _Player_;
    }));

    it('search should query api', function(){
        $scope.name = 'name';
        $scope.current = 100;
        $scope.potential = 200;
        player.search($scope);
        httpBackend.flush();
        expect($scope.players.length).toBe(1);
    });
});