(function () {
    'use strict';

    function genreRestService($http, $q) {

        var baseUrl = "http://localhost:61412/";

        var genreList = [];

        var save = function (genreInfo) {

            var deferred = $q;

            $http.post(baseUrl + "api/genre", genreInfo).then(function(response) {

                deferred.resolve(response);
            }, function(error) {
                deferred.reject(error);
            });

            return deferred.promise;
            
        }

        var list = function () {

            var deffered = $q.defer();

            $http.get(baseUrl + "api/genre").then(function(result) {

                deffered.resolve(result);
            }, function (error) {
                deffered.reject(error);
            });

            return deffered.promise;
        }

        return {
            save: save,
            list:list
        }
    }

    genreRestService.$inject = ['$http','$q'];

    angular.module('app').service('genreRestService', genreRestService);

})();