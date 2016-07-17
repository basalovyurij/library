(function () {
    'use strict';

    angular.module('app', [
        'ngRoute',
        'ngSanitize',
        'ui.select', 
        'naif.base64',
        'ja.isbn',
        'authorService',
        'bookService'
    ])

    // routing
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider
            .when('/books', {
                templateUrl: '/Templates/book-list.html',
                controller: 'BookListController'
            })
            .when('/book/add', {
                templateUrl: '/Templates/book-edit.html',
                controller: 'BookAddController'
            })
            .when('/book/edit/:id', {
                templateUrl: '/Templates/book-edit.html',
                controller: 'BookEditController'
            })
            .when('/book/delete/:id', {
                templateUrl: '/Templates/book-delete.html',
                controller: 'BookDeleteController'
            })

            .when('/authors', {
                templateUrl: '/Templates/author-list.html',
                controller: 'AuthorListController'
            })
            .when('/author/add', {
                templateUrl: '/Templates/author-edit.html',
                controller: 'AuthorAddController'
            })
            .when('/author/edit/:id', {
                templateUrl: '/Templates/author-edit.html',
                controller: 'AuthorEditController'
            })
            .when('/author/delete/:id', {
                templateUrl: '/Templates/author-delete.html',
                controller: 'AuthorDeleteController'
            })

            .when('/notfound', {
                templateUrl: '/Templates/notfound.html'
            })
            .otherwise('/notfound');

        $locationProvider.html5Mode(true);
    }])

    // default page
    .run(['$location', function ($location) {
        if($location.path() === "/") {
            $location.path('/books');
        }
    }])
})();