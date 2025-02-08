export default {
    content: [
        './**/*.html',
        './**/*.razor',
        './**/*.cshtml',
        './**/*.js',
        '!./node_modules/**/*'
    ],
    theme: {
        extend: {
            textUnderlineOffset: {
                1: '1px',
                2: '2px',
                4: '4px',
                8: '8px',
                12: '12px',
                16: '16px',
            },
        },
    },
    plugins: [],
};