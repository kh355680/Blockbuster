(function() {
    'use strict';

    function genreService(genreRestService, utilityService, $q) {
        
        this.setGenreViewModel = function(genreInfo) {

            return {
                id: utilityService.guid(),
                name:genreInfo.name
            }
        }

        this.resetGenreViewModel = function() {
            return {
                id: null,
                name:null
            }
        }

        this.saveNewGenre = function(newGenre) {

            var deferred = $q;
            genreRestService.save(newGenre).then(function(response) {

                deferred.resolve(response);
            },function(error) {
                deferred.reject(error);
            });

            return deferred.promise;
        }

        this.getGenreList = function() {

            var deffered = $q.defer();

            genreRestService.list().then(function (result) {
                deffered.resolve(result);
            },function(error) {
                deffered.reject(error);
            });

            return deffered.promise;
        }
    }

    genreService.$inject = ['genreRestService', 'utilityService','$q'];

    angular.module('app').service('genreService', genreService);

})();