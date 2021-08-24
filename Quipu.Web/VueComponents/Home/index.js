import Vue from 'vue';
import DashboardComponent from './dashboard.vue';
import HomeComponent from './home.vue';

new Vue({
    el: "#app",
    components: {
        DashboardComponent,
        HomeComponent
    }
})