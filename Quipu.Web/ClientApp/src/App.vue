<template>
    <q-layout view="lHh Lpr lFf">

        <q-drawer :model-value="leftDrawerOpen"
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
    body.desktop .q-focusable:focus .q-focus-helper,
    body.desktop .q-hoverable:hover .q-focus-helper {
        opacity: 0 !important;
    }

    .q-header .q-tab__content{
        min-width:0px !important;
    }

    .q-textarea .q-field__native{
        padding-top:5px !important;
    }

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
