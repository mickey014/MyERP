// MyERP — shared client-side behavior.
(function () {
    'use strict';

    // Enable Bootstrap dropdowns/tooltips app-wide if present.
    document.addEventListener('DOMContentLoaded', function () {
        var tooltipEls = document.querySelectorAll('[data-bs-toggle="tooltip"]');
        tooltipEls.forEach(function (el) {
            if (window.bootstrap && window.bootstrap.Tooltip) {
                new window.bootstrap.Tooltip(el);
            }
        });
    });
})();
