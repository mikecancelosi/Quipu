<template>
    <q-layout view="lHh Lpr lFf">

        <q-drawer v-model="leftDrawerOpen"
                  show-if-above
                  bordered>           
            <navmenu />
        </q-drawer>

        <q-page-container>
            <router-view/>
        </q-page-container>
    </q-layout>
</template>

<style>
</style>

<script>
    
    import navmenu from './components/NavMenu'
    import { mapGetters } from 'vuex'

    export default {
        name: 'LayoutDefault',      
        components: { navmenu },
        computed: mapGetters(['leftDrawerOpen']),       
        mounted() {
            this.$router.push('/Home');
            
        }

    }


</script>
