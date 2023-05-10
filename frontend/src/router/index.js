import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../views/HomeView.vue'
import PageNotFound from '../views/PageNotFound.vue'
import AboutView from '../views/AboutView.vue'
import HowToPlayView from '../views/HowToPlayView.vue'

import FriendsRequestView from '../views/Profile/FriendsRequestView.vue'
import SignView from '../views/Profile/SignView.vue'
import RegisterView from '../views/Profile/RegisterView.vue'
import SocialView from '../views/Profile/SocialView.vue'

import ErrorView from '../views/ErrorView.vue'
import GameView from '../views/MathGame/GameView.vue'
import GameResultView from '../views/MathGame/GameResultView.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/sign',
      name: 'sign',
      component: SignView
    },
    {
      path: '/register',
      name: 'register',
      component: RegisterView
    },
    {
      path: '/social',
      name: 'social',
      component: SocialView
    },
    {
      path: '/friends/request',
      name: 'friendRequest',
      component: FriendsRequestView
    },
    {
      path: '/mathgame/:difficulty',
      name: 'mathgame',
      component: GameView
    },
    {
      path: '/mathgame/result',
      name: 'result',
      component: GameResultView
    },
    {
      path: '/howtoplay',
      name: 'howtoplay',
      component: HowToPlayView
    },
    {
      path: '/about',
      name: 'about',
      component: AboutView
    },
    {
      path: '/error',
      name: 'error',
      component: ErrorView
    },
    { 
      path: '/:pathMatch(.*)*', 
      component: PageNotFound 
    }
  ]
})

export default router
