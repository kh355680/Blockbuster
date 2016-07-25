(function () {
    'use strict';

    function utilityService() {

        this.guid = function() {
         
            function s4() {
                return Math.floor((1 + Math.random()) * 0x10000)
                  .toString(16)
                  .substring(1);
            }
            return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
              s4() + '-' + s4() + s4() + s4();
        }        
    }

    angular.module('common.service').service('utilityService', utilityService);

})();