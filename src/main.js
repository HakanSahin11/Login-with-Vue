import Vue from 'vue'
//import Login from '@/components/Login';
//import MainSite from '@/components/MainSite'
import VueRouter from 'vue-router'

import App from './App.vue'
import BootstrapVue from 'bootstrap-vue'
import VueSimpleAlert from "vue-simple-alert";
import VueMaterial from 'vue-material'
import 'vue-material/dist/vue-material.min.css'
import 'vue-material/dist/theme/default.css'
import axios from 'axios';

Vue.use(VueRouter)

Vue.prototype.$http = axios
Vue.use(VueMaterial);
Vue.use(VueSimpleAlert);
Vue.use(BootstrapVue);

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

Vue.config.productionTip = false



new Vue({
  render: h => h(App),
}).$mount('#app')

