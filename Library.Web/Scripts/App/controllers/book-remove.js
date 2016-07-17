(function () {
    'use strict';

    angular
        .module('app')
        .controller('BookDeleteController', BookDeleteController);

    BookDeleteController.$inject = ['$scope', '$routeParams', '$location', 'Book'];

    function BookDeleteController($scope, $routeParams, $location, Book) {
        $scope.book = Book.get({ id: $routeParams.id });
        $scope.remove = function () {
            $scope.book.$remove({ id: $scope.book.Id }, function () {
                $location.path('/books');
            });
        };
    }
})();