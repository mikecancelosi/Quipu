<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <q-select :hide-dropdown-icon="!hover"
                  borderless
                  v-model="newpriority"
                  @update:model-value="updatetask()"
                  :options="allPriorityDropdownOptions"
                  dense
                  emit-value>

            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        <div>
                            <q-icon name="o_check"
                                    size="16px"
                                    :style="{visibility: scope.opt.category == (newpriority.id ?? 0)
                                                                              ? 'visible'
                                                                              : 'hidden'}" />
                            <q-badge rounded 
                                     :color="scope.opt.value.color">
                                {{scope.opt.label}}
                            </q-badge>
                        </div>
                    </q-item-section>
                </q-item>
            </template>
            <template v-slot:selected>
                <q-badge rounded
                         :color="newpriority.color ?? 'primary'"
                         v-if="newpriority != null">
                    {{newpriority.name }}
                </q-badge>
            </template>

        </q-select>

    </div>
</template>

<style scoped>
    .cell {
        width: 100%;
        height: 100%;
    }
</style>

<script>
    import { mapGetters, mapActions } from 'vuex'
    import { ref,reactive } from 'vue'

    export default {
        name: "PriorityCell",
        emits: ["update-task"],
        computed: mapGetters(['allPriorityDropdownOptions']),
        created() {
            this.fetchPriorityTypes();
        },
        props: {
            priority: {},            
        },
        setup(props) {
            const hover = ref(false);
            const showdropdown = ref(false);
            const newpriority = reactive(props?.priority ?? {});

            const updatetask = () => {
                this.$emit("update-task", this.newpriority);
            };          

            return {hover,showdropdown,newpriority,updatetask}
        },
        methods: {
             ...mapActions(['fetchPriorityTypes']),
        },
        updated() {
            this.newpriority = this.priority;
        }
    }
</script>