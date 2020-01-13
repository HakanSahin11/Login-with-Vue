<template>
  <div id="app"> 
  <!--  <nav>
      <router-link to="./components/Login.vue" >Login</router-link>
      <router-link to="./components/MainSite.vue" >Main</router-link>
    </nav>
    <router-view/> -->

   <Login msg="Welcome to Your Vue.js App"/> 
  </div>
</template>

<script>

import Login from './components/Login.vue'

/*
import Vue from 'vue'
import VueRouter from 'vue-router'
Vue.use(VueRouter)

const LoginInitiate  = {
  template: '<div>Login</div>'
}

const MainSiteInitiate = {
  template: '<div>MainSite</div>'
}

const router = new VueRouter({
  routes: [
    {path: '/Login', component:LoginInitiate},
    {path: '/MainSite', component:MainSiteInitiate},
  ]
})
*/
/*
new Vue({
  router
}).$mount('#app')
this.$router.push('/Login')
*/

export default {
  name: "App",
  components: {
    Login
  },
  data() {
    return {
    results: [],
    };
  }
}
</script>


<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}


</style>
