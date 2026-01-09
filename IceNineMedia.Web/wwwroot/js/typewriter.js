window.initTypewriter = function (technologies) {
    const element = document.getElementById('typewriter-text');
    
    if (!element) {
        console.log('Exiting: element not found');
        return;
    }
    
    // Ensure we have an array of strings
    let techArray;
    if (Array.isArray(technologies)) {
        techArray = technologies.map(t => String(t));
    } else if (typeof technologies === 'string') {
        // If a single string was passed, wrap it in an array
        console.warn('Received single string instead of array, wrapping in array');
        techArray = [technologies];
    } else {
        console.error('Invalid technologies format');
        return;
    }
    
    console.log('Final tech array:', techArray);
    console.log('Array length:', techArray.length);
    
    if (techArray.length === 0) {
        console.log('Exiting: empty array');
        return;
    }

    let currentIndex = 0;
    let currentCharIndex = 0;
    let isDeleting = false;
    let isPaused = false;

    function type() {
        const currentText = techArray[currentIndex];
        
        if (isPaused) {
            setTimeout(type, 1500);
            isPaused = false;
            return;
        }

        if (isDeleting) {
            element.textContent = currentText.substring(0, currentCharIndex - 1);
            currentCharIndex--;
        } else {
            element.textContent = currentText.substring(0, currentCharIndex + 1);
            currentCharIndex++;
        }

        let typeSpeed = isDeleting ? 50 : 100;

        if (!isDeleting && currentCharIndex === currentText.length) {
            isPaused = true;
            isDeleting = true;
            typeSpeed = 1500;
        } else if (isDeleting && currentCharIndex === 0) {
            isDeleting = false;
            currentIndex = (currentIndex + 1) % techArray.length;
            typeSpeed = 500;
        }

        setTimeout(type, typeSpeed);
    }

    type();
};