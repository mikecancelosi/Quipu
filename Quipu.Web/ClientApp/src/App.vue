<template>
    <v-app theme="dark">
        <nav-menu :isExpanded ="this.isNavExpanded" @collapseNav="this.collapse" />
        <div class="Quipu-Content">
            <div class="btn-right">
                <v-btn icon="mdi-forwardburger" @click="expand" />
            </div>
            <router-view />
        </div>
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

    .v-app {
        position: relative;
        right: 0;
        left: 0;
        bottom: 0;
        top: 0;
    }

    .Quipu-Content {
        position: relative;       
        width:100%
    }

    .nav-menu {
        position: relative;
        width:256px;
    }
</style>

