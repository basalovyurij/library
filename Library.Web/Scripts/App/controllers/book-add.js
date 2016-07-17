(function () {
    'use strict';

    angular
        .module('app')
        .controller('BookAddController', BookAddController);

    BookAddController.$inject = ['$scope', '$location', 'Author', 'Book'];

    function BookAddController($scope, $location, Author, Book) {
        $scope.book = new Book();
        $scope.authors = Author.query();
        $scope.select = { authors: [] };

        $scope.editBook = function () {
            if (!$scope.form.$valid)
                return;

            $scope.book.Authors = $scope.select.authors;
            if ($scope.file) {
                $scope.book.Image = "data:" + $scope.file.filetype + ";base64," + $scope.file.base64;
            }

            $scope.book.$save(function () {
                $location.path('/books');
            }, function (e) {
                $scope.validationErrors = e.data.Errors;
            });
        };
    }
})();