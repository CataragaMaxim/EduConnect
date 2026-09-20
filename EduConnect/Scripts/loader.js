window.addEventListener('beforeunload', function () {
     const loader = document.getElementById('loader-overlay');
     if (loader) loader.style.display = 'flex';
});

document.addEventListener('DOMContentLoaded', function () {
     const forms = document.querySelectorAll("form");
     forms.forEach(function (form) {
          form.addEventListener("submit", function () {
               const loader = document.getElementById('loader-overlay');
               if (loader) loader.style.display = 'flex';
          });
     });
});
