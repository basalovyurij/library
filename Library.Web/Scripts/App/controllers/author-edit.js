(function () {
    'use strict';

    angular
        .module('app')
        .controller('AuthorEditController', AuthorEditController);

    AuthorEditController.$inject = ['$scope', '$routeParams', '$location', 'Author'];

    function AuthorEditController($scope, $routeParams, $location, Author) {
        $scope.author = Author.get({ id: $routeParams.id });

        $scope.editAuthor = function () {
            if (!$scope.form.$valid)
                return;

            $scope.author.$save({ id: $routeParams.id }, function () {
                $location.path('/authors');
            }, function (e) {
                $scope.validationErrors = e.data.Errors;
            });
        };
    }

})();