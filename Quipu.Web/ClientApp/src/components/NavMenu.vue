<template>
   <div>

   </div>
</template>


<script>
    export default {
        name: "NavMenu",
        props: {
            isExpanded: Boolean
        },
        methods: {
            collapse() {
                this.$emit('collapse-nav');
            },
        }
    }
</script>

<style scoped>
   
</style>
