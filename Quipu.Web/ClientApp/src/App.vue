<template>
    <v-app theme="dark">
        
            <nav-menu :isExpanded="this.isNavExpanded" @collapseNav="this.collapse" />
            <v-content>               
                <v-btn icon="mdi-forwardburger" @click="expand" />
                <router-view />
            </v-content>
    </v-app>
</template>

<script>
    import NavMenu from './components/NavMenu.vue'

    export default {
        name: 'App',
        components: {
            NavMenu
        },
        data() {
            return {
                isNavExpanded: true,
            }
        },
        methods: {
            expand() {
                this.isNavExpanded = true;
            },
            collapse() {
                this.isNavExpanded = false;
            }
        }
    }
</script>

<style scoped>

    .Quipu-Content {  
        width:70%;
        order:2;

    }

    .nav-menu {
        width:256px;
        order:1;
    }
    .container{
        display:flex;
        flex-direction:column;
        width:fit-content;
    }
</style>

