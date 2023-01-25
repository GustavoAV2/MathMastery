import { http } from "../services/config";

export default{
  createGame(difficulty) {
    return http.get('/game/create/' + difficulty);
  },
  nextGame(gameDto) {
    return http.post('/game/next', gameDto);
  },
  postResultGame(gameDto) {
    return http.post('/game/result', gameDto);
  }
}
