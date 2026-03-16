import { useState, useEffect } from "react";
import API from "./services/api";

function App() {

  const [movies, setMovies] = useState([]);

  useEffect(() => {

    const token = localStorage.getItem("token");

    if (!token) {
      login();
    } else {
      getMovies();
    }

  }, []);

  async function login() {
    try {

      const res = await API.post("/login", {
        username: "iremezgi",
        password: "123456"
      });

      const token = res.data.token;

      localStorage.setItem("token", token);

      getMovies();

    } catch (err) {
      console.log(err.response?.data || err);
    }
  }

  async function getMovies() {
  try {
    const token = localStorage.getItem("token");

    const res = await API.get("/movies", {
      headers: {
        Authorization: `Bearer ${token}`
      }
    });

    console.log("API RESPONSE:", res.data);

    setMovies(res.data.data.movies);

  } catch (err) {
    console.log(err);
  }
}

  return (
    <div>

      <h1>Movies</h1>

      {movies.map((movie) => (
        <div key={movie._id}>
          {movie.title} ({movie.year}) ⭐ {movie.rating}
        </div>
      ))}

    </div>
  );
}

export default App;