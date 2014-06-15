'use strict';

describe('Application controllers', function(){
    beforeEach(module('app.controllers'));

    it('should have playerCtrl', inject(function($controller){
        var ctrl = $controller('playerCtrl', { $scope: {} });
        expect(ctrl).toBeDefined();
    }));

    it('should have clubCtrl', inject(function($controller){
        var ctrl = $controller('clubCtrl', { $scope: {} });
        expect(ctrl).toBeDefined();
    }));

    it('should have homeCtrl', inject(function($controller){
        var ctrl = $controller('homeCtrl', { $scope: {} });
        expect(ctrl).toBeDefined();
    }));
});