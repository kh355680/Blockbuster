(function () {
    'use strict';

    function layoutController() {

        var vm = this;

        function init() {

            console.log('layout controller initiated');
        }

        init();
    }

    angular.module('app').controller('layoutController', layoutController);

})();