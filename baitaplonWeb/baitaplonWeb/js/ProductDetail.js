document.addEventListener('DOMContentLoaded', function () {
    const prevBtn = document.querySelector('.prev-btn');
    const nextBtn = document.querySelector('.next-btn');
    const sliderContainer = document.querySelector('.slider-container');
    const images = document.querySelectorAll('.slider-image');
    let currentIndex = 0;

    function updateSlider() {
        const offset = -currentIndex * 100;
        sliderContainer.style.transform = `translateX(${offset}%)`;
    }

    prevBtn.addEventListener('click', function () {
        currentIndex = (currentIndex > 0) ? currentIndex - 1 : images.length - 1;
        updateSlider();
    });

    nextBtn.addEventListener('click', function () {
        currentIndex = (currentIndex < images.length - 1) ? currentIndex + 1 : 0;
        updateSlider();
    });
});
