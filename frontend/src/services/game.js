import { http } from "./config";

export default {
  createGame(difficulty) {
    return http.get('/game/create?difficulty=' + difficulty);
  },
  nextGame(gameDto) {
    return http.post('/game/next', gameDto);
  },
  postResultGame(gameDto) {
    return http.post('/game/result', gameDto);
  }
};
