<template>
    <p> Task List! </p>

    <q-list v-for="task in tasks" :key="task">
        <q-icon flat
                round
                name="o_face"
                style="margin-right:5px; font-size:32px;" />
    </q-list>

</template>

<style scoped>
</style>


<script>
    export default {
        name: "MyTasksList",
        props: {
            tasks:[]
        },
    }
</script>