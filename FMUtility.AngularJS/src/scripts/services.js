'use strict';

angular.module('app.services', [])
    .factory('UrlHelper', function() {
        return {
            baseUrl: 'http://localhost:9000/',
            buildUrl: function(baseUrl, parts){
                var hasValues = false;
                var url = baseUrl;
                for(var i = 0; i < parts.length; i++){
                    if(!hasValues) {
                        if (parts[i] != null){
                            url += '?' + parts[i];
                            hasValues = true;
                        }
                    }
                    else if(parts[i] != null){
                        url += '&' + parts[i];
                    }
                }
                return url;
            }
        }
    })
    .factory('Player', function($http, UrlHelper){
        return {
            search: function($scope){
                var url = this.buildSearchUrl($scope);
                return $http.get(url)
                    .then(function(response){
                        $scope.players = response.data;
                    });
            },
            buildSearchUrl: function($scope){
                var url = UrlHelper.baseUrl + 'player/search';
                var namePart = $scope.name == null ? null : 'name=' + $scope.name;
                var currentPart = $scope.current == null ? null : 'current=' + $scope.current;
                var potentialPart = $scope.potential == null ? null : 'potential=' + $scope.potential;
                return UrlHelper.buildUrl(url, [namePart, currentPart, potentialPart]);
            }
        }
    })
    .value('version', '0.1');