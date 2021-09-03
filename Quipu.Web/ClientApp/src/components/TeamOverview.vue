<template>
    <p>Overview! {{team.id}}</p>
</template>

<script>
    export default {
        name: 'LayoutDefault',
        props: {
            team: {},
        },
        data() {
            return {
                leftDrawerOpen: true,
            }
        },
        methods: {
        },
        mounted() {
            console.log(this.team);
        }

    }
</script>