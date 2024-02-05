import OwlCarousel from 'react-owl-carousel';
import 'owl.carousel/dist/assets/owl.carousel.css';
import 'owl.carousel/dist/assets/owl.theme.default.css';

function Home(){
    //Owl Carousel Settings
    const options = {
        loop: true,
        center: true,
        items: 1,
        margin: 0,
        autoplay: true,
        dots: true,
        autoplayTimeout: 8500,
        smartSpeed: 450,
        nav: false,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 1
            },
            1000: {
                items: 1
            }
        }
    };
    return (
        <OwlCarousel className='owl-theme' {...options}>
            <div class='item'>
                <img src='/img/carousel-1.jpg'/>
            </div>
            <div class='item'>
                <img src='/img/carousel-2.jpg'/>
            </div>
            <div class='item'>
                <img src='/img/carousel-3.jpg'/>
            </div>
        </OwlCarousel>
    )
}

export default Home;
