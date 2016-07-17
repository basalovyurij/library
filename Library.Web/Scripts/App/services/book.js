(function () {
    'use strict';

    angular
        .module('bookService', ['ngResource'])
        .factory('Book', Book);

    Book.$inject = ['$resource'];

    function Book($resource) {
        var res = $resource('/api/Book/:id', null, {
            'create': { method: 'POST' },
            'update': { method: 'PUT' }
        });

        res.prototype.$save = function (params, success, error) {
            if (this.Id) {
                return this.$update(params, success, error);
            } else {
                return this.$create(params, success, error);
            }
        };

        return res;
    }
})();