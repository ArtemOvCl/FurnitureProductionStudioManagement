/** @type {import('tailwindcss').Config} */
module.exports = {

  content: [
    "./src/**/*.{html,ts}",
  ],
  theme: {
    extend: {
      colors: {
        'beige': '#faf0e6',
        'green-dark-800': '#172621',
        'green-dark-400': '#2A4038',
        'green-dark-200': '#3B593F',
        'green-light': '#4D734C'
      },
      fontSize: {
        '10xl': '12rem', 
        '11xl': '16rem', 
      },
      fontFamily: {
        bebas: ['"Bebas Neue"', 'sans-serif'],
        lexend: ['Lexend', 'sans-serif'],
        raleway: ['Raleway', 'sans-serif'],
        redhat: ['"Red Hat Display"', 'sans-serif'],
        ubuntu: ['Ubuntu', 'sans-serif'],
      },
    },
  },
  plugins: [],
}
