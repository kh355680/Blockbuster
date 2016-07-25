(function () {
    'use strict';

    routeManager.$inject = ['$stateProvider', '$urlRouterProvider'];

    function routeManager($stateProvider, $urlRouterProvider) {

        $stateProvider
            .state('layout', {
                abstract: true,
                url: '/',
                templateUrl: 'app/layout/layout.view.html',
                controller: 'layoutController',
                controllerAs: 'vm'
            })
            .state('layout.home', {
                url: 'home',
                templateUrl: 'app/home/home.view.html',
                controller: 'homeController',
                controllerAs: 'vm'
            })
            .state('layout.genre', {
                url: 'genre',
                templateUrl: 'app/genre/genre.view.html',
                controller: 'genreController',
                controllerAs:'vm'
    });

        $urlRouterProvider.when('', '/home');

    }

    angular.module('app', ['ui.router','common.service']).config(routeManager);

   
})();