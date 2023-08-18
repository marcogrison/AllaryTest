$(document).ready(function () {
    $('.carousel-item img').css('max-width', '600px');

    document.getElementById('getDataButton').addEventListener('click', function (e) {
        const table = document.querySelector('.table');
        table.innerHTML = ''; // Clear the table content

        const loadingSpinner = document.querySelector('.loading-spinner');
        loadingSpinner.style.display = 'block';

        const rippleEffect = document.createElement('div');
        rippleEffect.classList.add('ripple-effect');
        const rect = this.getBoundingClientRect();
        const size = Math.max(rect.width, rect.height);
        const x = e.clientX - rect.left - size / 2;
        const y = e.clientY - rect.top - size / 2;
        rippleEffect.style.width = rippleEffect.style.height = `${size}px`;
        rippleEffect.style.left = `${x}px`;
        rippleEffect.style.top = `${y}px`;
        this.appendChild(rippleEffect);

        fetch('/Home/GetData')
            .then(response => response.text())
            .then(data => {
                table.innerHTML = data; // Replace table content with fetched data
                loadingSpinner.style.display = 'none'; // Hide the loading spinner
            })
            .catch(error => {
                console.error('Error:', error);
                table.innerHTML = '<tr><td colspan="4">Error loading data.</td></tr>'; // Display an error message in the table
                loadingSpinner.style.display = 'none'; // Hide the loading spinner in case of error
            });
    });
});

document.addEventListener("DOMContentLoaded", function () {
    var mousePositionX = document.getElementById("mousePositionX");
    var mousePositionY = document.getElementById("mousePositionY");

    document.addEventListener("mousemove", function (event) {
        var x = event.clientX;
        var y = event.clientY;
        mousePositionX.textContent = "X: " + x + "px";
        mousePositionY.textContent = "Y: " + y + "px";
    });
});
