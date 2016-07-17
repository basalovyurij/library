(function () {
    'use strict';

    angular
        .module('app')
        .controller('BookListController', BookListController);

    BookListController.$inject = ['$scope', 'Book'];

    function BookListController($scope, Book) {
        $scope.books = Book.query();

        var storage = window.sessionStorage;

        $scope.getSortType = function () {
            return storage.getItem('sortType');
        };

        $scope.setSortType = function (value) {
            return storage.setItem('sortType', value);
        };

        $scope.getSortReverse = function () {
            return storage.getItem('sortReverse') == 'true';
        };

        $scope.setSortReverse = function (value) {
            return storage.setItem('sortReverse', value);
        };

        $scope.getSortType() || $scope.setSortType('Name');
        undefined == $scope.getSortReverse() || $scope.setSortReverse('false');
    }
})();