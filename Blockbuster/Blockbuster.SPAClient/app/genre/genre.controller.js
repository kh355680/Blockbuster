(function () {
    'use strict';

    function genreController(genreService, utilityService) {

        var vm = this;

        var init = function () {

            vm.isAddedMode = true;
            vm.isUpdateMode = false;

            //vm.genres = genreService.getGenreList();
            genreService.getGenreList().then(function(response) {
                vm.genres = response.data;
            },function(error) {
                console.log(error);
            });
            
        }

        vm.genres = [];

        vm.save = function(genreInfo) {
            vm.genre = genreService.setGenreViewModel(genreInfo);
            genreService.saveNewGenre(vm.genre).then(function(response) {
                console.log('success',response);
            },function(reject) {
                console.log('failure',reject);
            });
            vm.genre = genreService.resetGenreViewModel();
            init();
        }

        vm.edit = function(genreInfo) {
            vm.genre = genreInfo;
            vm.isAddedMode = false;
            vm.isUpdateMode = true;
        }
        vm.update = function () {
            

            vm.genres.forEach(function (genre) {
                
                if (genre.id === vm.genre.id) {
                    genre = vm.genre;
                }
            });
            console.log(vm.genre);
            vm.reset();
            init();
        }
        
        vm.reset = function() {
            vm.genre = genreService.setGenreViewModel();
        }

        init();

    }

    genreController.$inject = ['genreService','utilityService'];
    angular.module('app').controller('genreController', genreController);

})();