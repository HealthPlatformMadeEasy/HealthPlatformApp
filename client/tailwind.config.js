/** @type {import('tailwindcss').Config} */
// eslint-disable-next-line no-undef
module.exports = {
  content: [
    "./index.html",
    "./src/**/*.{js,ts,jsx,tsx}",
    "./node_modules/tw-elements/dist/js/**/*.js",
  ],
  theme: {
    extend: {
      backgroundImage: {
        "yellow-fruit-left": "url('./assets/yellow-fruit-left.png')"
      },
      fontFamily: {
        montserrat: ["Montserrat", "sans-serif"],
        playfair: ["Playfair Display", "Montserrat", "sans-serif"],
      },
      colors: {
        tea_green: {
          DEFAULT: "#cfffb3",
          900: "#205700",
          800: "#40ad00",
          700: "#61ff05",
          600: "#98ff5c",
          500: "#cfffb3",
          400: "#d8ffc2",
          300: "#e2ffd1",
          200: "#ecffe0",
          100: "#f5fff0",
        },
        marian_blue: {
          DEFAULT: "#003f91",
          900: "#000c1d",
          800: "#001939",
          700: "#002556",
          600: "#003272",
          500: "#003f91",
          400: "#005ed8",
          300: "#2382ff",
          200: "#6cacff",
          100: "#b6d5ff",
        },
        pine_green: {
          DEFAULT: "#136f63",
          900: "#041613",
          800: "#072c27",
          700: "#0b413a",
          600: "#0f574e",
          500: "#136f63",
          400: "#1eae9b",
          300: "#3bdec8",
          200: "#7ce9da",
          100: "#bef4ed",
        },
        madder: {
          DEFAULT: "#b10f2e",
          900: "#240309",
          800: "#470612",
          700: "#6b091b",
          600: "#8f0c24",
          500: "#b10f2e",
          400: "#eb163d",
          300: "#f0506e",
          200: "#f58b9e",
          100: "#fac5cf",
        },
        light_coral: {
          DEFAULT: "#ef767a",
          900: "#400709",
          800: "#800f13",
          700: "#c0161c",
          600: "#e7363c",
          500: "#ef767a",
          400: "#f29195",
          300: "#f5adaf",
          200: "#f9c8ca",
          100: "#fce4e4",
        },
      },
    },
  },
  darkMode: "class",
  // eslint-disable-next-line no-undef
  plugins: [require("tw-elements/dist/plugin.cjs")],
};
