(function () {
    'use strict';

    angular
        .module('app')
        .controller('BookEditController', BookEditController);

    BookEditController.$inject = ['$scope', '$routeParams', '$location', 'Author', 'Book'];

    function BookEditController($scope, $routeParams, $location, Author, Book) {
        $scope.book = Book.get({ id: $routeParams.id }, function () {
            $scope.select = { authors: $scope.book.Authors };
        });
        $scope.authors = Author.query();
        
        $scope.editBook = function () {
            if (!$scope.form.$valid)
                return;

            $scope.book.Authors = $scope.select.authors;
            if ($scope.file) {
                $scope.book.Image = "data:" + $scope.file.filetype + ";base64," + $scope.file.base64;
            }

            $scope.book.$save({ id: $routeParams.id }, function () {
                $location.path('/books');
            }, function (e) {
                $scope.validationErrors = e.data.Errors;
            });
        };
    }

})();