(function () {
    'use strict';

    function homeController() {

        var vm = this;


        function init() {
            
            console.log('home controller initiated');
        }

        init();
    }

    angular.module('app').controller('homeController', homeController);

})();